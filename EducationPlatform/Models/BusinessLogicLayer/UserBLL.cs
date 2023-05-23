using EducationPlatform.Exceptions;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EducationPlatform.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        private readonly UserDAL _userRepository;

        public UserBLL(UserDAL userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetByID(id);
        }

        public void AddUser(User user)
        {
            if (ValidateUser(user))
            {
                var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    throw new InvalidOperationException("A user with the same username already exists.");
                }
                _userRepository.Insert(user);
            }
        }

        public void UpdateUser(User user)
        {
            if (ValidateUser(user))
            {
                var existingUser = _userRepository.GetByID(user.Id);
                if (existingUser == null)
                {
                    MessageBox.Show("User not found.");
                    return;
                }
                _userRepository.Update(user);
            }
        }

        public void DeleteUser(User user)
        {
            var existingUser = _userRepository.GetByID(user.Id);
            if (existingUser == null)
            {
                MessageBox.Show("User not found.");
                return;
            }
            _userRepository.Delete(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        public User? GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is required.");
                return null;
            }
            var user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                MessageBox.Show("User not found.");
                return null;
            }
            return user;
        }
        public bool ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                MessageBox.Show("User name is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                MessageBox.Show("Password is required.");
                return false;
            }
            return true;
        }

    }
}
