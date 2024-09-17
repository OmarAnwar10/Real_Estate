﻿namespace _Services.Models.User
{
    public class User_Basic
    {

        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string ProfilePicture { get; set; }

        public int? Num_of_Properties { get; set; }
        public int? Num_of_Inquiries { get; set; }
    }
}
