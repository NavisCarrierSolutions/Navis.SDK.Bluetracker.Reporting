﻿using System;

namespace Navis.SDK.Bluetracker.Reporting.Core
{
    public class HttpException : Exception
    {
        /// <summary>
        /// Gets  the Http status code.
        /// </summary>
        public int StatusCode { get; }

        /// <inheritdoc />
        /// <summary>
        /// Creates a new instance of the <see cref="T:Navis.SDK.Bluetracker.Reporting.Core.HttpException" /> class.
        /// </summary>
        /// <param name="statusCode">Status code of error.</param>
        /// <param name="message">Message providing more information about the error.</param>
        public HttpException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}