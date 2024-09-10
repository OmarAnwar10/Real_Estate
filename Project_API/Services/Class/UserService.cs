using Application.ServiceContracts;
using application.DataAccess.Models;
using Application.DataAccessContracts;
using System.Collections.Generic;
using System.Linq;
using System;
using API_Project.DataAccess.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _unitOfWork.User.GetAll();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving users.", ex);
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                var user = _unitOfWork.User.Get(id);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }
                return user;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving the user.", ex);
            }
        }

        public void CreateUser(User user)
        {
            ValidateUser(user);

            try
            {
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

        public void UpdateUser(User user)
        {
            ValidateUser(user);

            try
            {
                var existingUser = _unitOfWork.User.Get(user.Id);
                if (existingUser == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                // Optional: update password only if provided
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = HashPassword(user.Password);
                }

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

        public User AuthenticateUser(string email, string password)
        {
            try
            {
                var user = _unitOfWork.User.GetAll()
                    .FirstOrDefault(u => u.Email == email && u.Password == HashPassword(password));

                if (user == null)
                {
                    throw new UnauthorizedAccessException("Invalid email or password.");
                }
                return user;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while authenticating the user.", ex);
            }
        }

        public IEnumerable<Property> GetUserProperties(int userId)
        {
            try
            {
                return _unitOfWork.Property.GetAll()
                    .Where(p => p.OwnerId == userId)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving user's properties.", ex);
            }
        }

        public IEnumerable<Inquiry> GetUserInquiries(int userId)
        {
            try
            {
                return _unitOfWork.Inquiry.GetAll()
                    .Where(i => i.UserId == userId)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving user's inquiries.", ex);
            }
        }

        public IEnumerable<Favorite> GetUserFavorites(int userId)
        {
            try
            {
                return _unitOfWork.Favorite.GetAll()
                    .Where(f => f.UserId == userId)
                    .ToList();
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
        private void ValidateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentException("User email is required.", nameof(user.Email));

            if (string.IsNullOrEmpty(user.Password))
                throw new ArgumentException("User password is required.", nameof(user.Password));

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
