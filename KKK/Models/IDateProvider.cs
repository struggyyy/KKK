using Microsoft.AspNetCore.Mvc;
using System;

namespace KKK.Models
{
    public interface IDateProvider
    {
        DateTime CurrentDate { get; }
    }
}
