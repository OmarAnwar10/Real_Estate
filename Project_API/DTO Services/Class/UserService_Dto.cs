using Application.ServiceContracts;
using application.DataAccess.Models;
using Application.DataAccessContracts;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using API_Project.DataAccess.DTOs;
using API_Project.DataAccess.DTOs_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project.DataAccess.Models;

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
        public void CreateUser(UserWithOutIdDto userWithOutIdDto)
        {
            ValidateUserDto(userWithOutIdDto);
            try
            {
                var user = _mapper.Map<User>(userWithOutIdDto);
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

        public void UpdateUser(int id, UserWithOutIdDto userWithOutIdDto)
        {
            ValidateUserDto(userWithOutIdDto);
            try
            {
                var existingUser = _unitOfWork.User.Get(id);
                if (existingUser == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                // Optional: update password only if provided
                if (!string.IsNullOrEmpty(userWithOutIdDto.Password))
                {
                    userWithOutIdDto.Password = HashPassword(userWithOutIdDto.Password);
                }

                var user = _mapper.Map<User>(userWithOutIdDto);
                user.Id = id;
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

        public IEnumerable<PropertyDto> GetUserProperties(int userId)/////error
        {
            try
            {
                // استعلام بسيط
                var properties = _unitOfWork.Property.GetAll();
                var filteredProperties = properties.Where(p => p.OwnerId == userId).ToList();
                //IEnumerable<User> users = new List<User>();
                //users.Append(_unitOfWork.User.Get(userId));
                //var query = filteredProperties.Join(
                //                users,
                //                propertie => propertie.OwnerId,
                //                user => user.Id,
                //                (propertie, user) => new
                //                {
                //                    usernName = user.Email,
                //                    propertieName = propertie.Title
                //                });
                return _mapper.Map<IEnumerable<PropertyDto>>(filteredProperties);
            }
            catch (Exception ex)
            {
                // سجل الاستثناء
                throw new ApplicationException("An error occurred while retrieving user's properties.", ex);
            }
        }


        public IEnumerable<InquiryDto> GetUserInquiries(int userId)////////needDto
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

        public IEnumerable<FavoriteDto> GetUserFavorites(int userId)/////////needDto
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
        private void ValidateUserDto(UserWithOutIdDto userDto)
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
