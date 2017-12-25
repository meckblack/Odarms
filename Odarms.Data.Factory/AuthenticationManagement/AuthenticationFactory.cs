﻿using Odarms.Data.Factory.SystemManagament;
using Odarms.Data.Objects.Entities.User;
using Odarms.Data.Service.Encryption;
using System;
using System.Data.Entity;
using System.Web.Security;

namespace Odarms.Data.Factory.AuthenticationManagement
{
    public class AuthenticationFactory
    {
        private Data.DataContext.DataContext.DataContext _db;

        #region Constructor

        public AuthenticationFactory()
        {
            _db = new Data.DataContext.DataContext.DataContext();
        }
        #endregion      

        /// <summary>
        ///     This method is used to authenticate a users login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AppUser AuthenticateAppUserLogin(string email, string password)
        {
            var hashPassword = new Md5Encryption().ConvertStringToMd5Hash(password.Trim());
            var user = new AppUserFactory().GetAppUserByLogin(email, hashPassword);
            return user;
        }
        /// <summary>
        ///     This method is used to send a forgot password request to fetch the user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public AppUser ForgotPasswordRequest(string email)
        {
            email = email.Trim();
            var user = new AppUserFactory().GetAppUserByEmail(email);
            var appuser = _db.AppUsers.Find(user.AppUserId);
            var newPassword = Membership.GeneratePassword(8, 1);
            appuser.Password = newPassword;
            _db.Entry(appuser).State = EntityState.Modified;
            _db.SaveChanges();
            //new MailerDaemon().ResetUserPassword(appuser);
            return user;
        }

        /// <summary>
        ///     This method is used to reset a user password
        /// </summary>
        /// <param name="newPassword"></param>
        /// <param name="userId"></param>
        public void ResetUserPassword(string newPassword, int userId)
        {
            var user = _db.AppUsers.Find(userId);
            user.Password = newPassword;
            var hashPasword = new Md5Encryption().ConvertStringToMd5Hash(newPassword);
            _db.Entry(user).State = EntityState.Modified;
            user.Password = hashPasword;
            _db.SaveChanges();
        }

        /// <summary>
        ///     This method generates a password hash from a clear password using MD5
        /// </summary>
        /// <param name="clearPassword">The clear password to be hashed</param>
        /// <returns>The hashed password</returns>
        public string GetPasswordHash(string clearPassword)
        {
            return new Md5Encryption().ConvertStringToMd5Hash(clearPassword);
        }

        /// <summary>
        ///     This method enables a user to change their password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangeUserPassword(long userId, string oldPassword, string newPassword)
        {
            var encryptedOldPassword = GetPasswordHash(oldPassword);
            if (encryptedOldPassword == null) throw new ArgumentNullException(nameof(encryptedOldPassword));
            var encryptedNewPassword = GetPasswordHash(newPassword);
            if (encryptedNewPassword == null) throw new ArgumentNullException(nameof(encryptedNewPassword));
            var isPasswordChanged = false;
            var user = _db.AppUsers.Find(userId);
            if (user.Password == encryptedOldPassword)
            {
                user.Password = encryptedNewPassword;
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                isPasswordChanged = true;
            }
            else
            {
                isPasswordChanged = false;
            }
            return isPasswordChanged;
        }

    }
}