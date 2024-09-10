using Application.ServiceContracts;
using application.DataAccess.Models;
using Application.DataAccessContracts;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using API_Project.DataAccess.DTOs;

namespace Application.Services
{
    public class UserService_Dto : IUserService_Dto
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService_Dto(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            try
            {
                var users = _unitOfWork.User.GetAll();
                return _mapper.Map<IEnumerable<UserDto>>(users);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving users.", ex);
            }
        }

        public UserDto GetUserById(int id)
        {
            try
            {
                var user = _unitOfWork.User.Get(id);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving the user.", ex);
            }
        }

        public void CreateUser(UserDto userDto)
        {
            ValidateUserDto(userDto);

            try
            {
                var user = _mapper.Map<User>(userDto);
                // Hash the password before saving
                user.Password = HashPassword(user.Password);
                _unitOfWork.User.Insert(user);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while creating the user.", ex);
            }
        }

        public void UpdateUser(UserDto userDto)
        {
            ValidateUserDto(userDto);

            try
            {
                var existingUser = _unitOfWork.User.Get(userDto.Id);
                if (existingUser == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                // Optional: update password only if provided
                if (!string.IsNullOrEmpty(userDto.Password))
                {
                    userDto.Password = HashPassword(userDto.Password);
                }

                var user = _mapper.Map<User>(userDto);
                _unitOfWork.User.Update(user);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while updating the user.", ex);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                var user = _unitOfWork.User.Get(id);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                _unitOfWork.User.Delete(id);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while deleting the user.", ex);
            }
        }

        public UserDto AuthenticateUser(string email, string password)
        {
            try
            {
                var user = _unitOfWork.User.GetAll()
                    .FirstOrDefault(u => u.Email == email && u.Password == HashPassword(password));

                if (user == null)
                {
                    throw new UnauthorizedAccessException("Invalid email or password.");
                }
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while authenticating the user.", ex);
            }
        }

        public IEnumerable<PropertyDto> GetUserProperties(int userId)
        {
            try
            {
                var properties = _unitOfWork.Property.GetAll()
                    .Where(p => p.OwnerId == userId)
                    .ToList();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving user's properties.", ex);
            }
        }

        public IEnumerable<InquiryDto> GetUserInquiries(int userId)
        {
            try
            {
                var inquiries = _unitOfWork.Inquiry.GetAll()
                    .Where(i => i.UserId == userId)
                    .ToList();
                return _mapper.Map<IEnumerable<InquiryDto>>(inquiries);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving user's inquiries.", ex);
            }
        }

        public IEnumerable<FavoriteDto> GetUserFavorites(int userId)
        {
            try
            {
                var favorites = _unitOfWork.Favorite.GetAll()
                    .Where(f => f.UserId == userId)
                    .ToList();
                return _mapper.Map<IEnumerable<FavoriteDto>>(favorites);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving user's favorites.", ex);
            }
        }

        public void UpdateUserPassword(int userId, string newPassword)
        {
            try
            {
                var user = _unitOfWork.User.Get(userId);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                user.Password = HashPassword(newPassword);
                _unitOfWork.User.Update(user);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while updating the user's password.", ex);
            }
        }

        // Private method to validate user data
        private void ValidateUserDto(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            if (string.IsNullOrEmpty(userDto.Email))
                throw new ArgumentException("User email is required.", nameof(userDto.Email));

            if (string.IsNullOrEmpty(userDto.Password))
                throw new ArgumentException("User password is required.", nameof(userDto.Password));

            // Add any additional validations as needed
        }

        // Private method to hash passwords
        private string HashPassword(string password)
        {
            // Implement password hashing logic here
            return password; // Replace this with actual hashing implementation
        }
    }
}
