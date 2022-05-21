﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.AspNetCore.Mvc;

namespace Snap.HutaoAPI.Models
{
    /// <summary>
    /// extension for response
    /// </summary>
    public static class ControllerExtension
    {
        public static IActionResult Success<T>(this ControllerBase _, string msg, T data)
        {
            return new JsonResult(new ApiResponse<T>(ApiCode.Success, msg, data));
        }

        public static IActionResult Success(this ControllerBase _, string msg)
        {
            return new JsonResult(new ApiResponse<object?>(ApiCode.Success, msg, null));
        }

        public static IActionResult Fail(this ControllerBase _, string msg)
        {
            return new JsonResult(new ApiResponse<object?>(ApiCode.Fail, msg, null));
        }

        public static IActionResult Fail(this ControllerBase _, ApiCode code, string msg)
        {
            return new JsonResult(new ApiResponse<object?>(code, msg, null));
        }
    }
}
