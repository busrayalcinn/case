﻿namespace Nowadays.Models.ResponseModels
{
    public class ResponseModel<T>
    {
        public int? StatusCode { get; set; }
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public T? Model { get; set; }
        public ResponseModel(T model)
        {
            Success = true;
            Model = model;
        }
        public ResponseModel(int statusCode, T model)
        {
            StatusCode = statusCode;
            Success = true;
            Model = model;
        }
        public ResponseModel(int statusCode, Exception exception)
        {
            StatusCode = statusCode;
            Success = false;
            Exception = exception;
            Message = "Error: " + exception.Message;
        }
    }
    public class ResponseModel
    {
        public int? StatusCode { get; set; }
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public ResponseModel(int statusCode, Exception exception)
        {
            StatusCode = statusCode;
            Success = false;
            Exception = exception;
            Message = "Error: " + exception.Message;
        }
        public ResponseModel(int statusCode, string message)
        {
            if(statusCode == 200 || statusCode == 201)
            {
                StatusCode = statusCode;
                Success = true;
                Message = message;
            }
            else
            {
                StatusCode = statusCode;
                Success = false;
                Message = message;
            }
        }
        public ResponseModel(string message)
        {
            Success = true;
            Message = message;
        }

    }
}
