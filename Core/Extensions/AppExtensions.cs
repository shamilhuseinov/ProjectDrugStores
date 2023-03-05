﻿using System;
using System.Text.RegularExpressions;

namespace Core.Extensions
{
	public static class AppExtensions
	{
        public static bool IsEmail(this string text)
        {
            return Regex.IsMatch(text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsCorrectNumber(this string text)
        {
            return Regex.IsMatch(text, @"^994[0-9]{9}$");
        }
    }
}

//^[\+]?994\s?[0-9]{9}$