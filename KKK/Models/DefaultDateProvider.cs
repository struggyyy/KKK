using Microsoft.AspNetCore.Mvc;
using System;

namespace KKK.Models
{
    public class DefaultDateProvider : IDateProvider
    {
        public DateTime CurrentDate => DateTime.Now;
    }
}
