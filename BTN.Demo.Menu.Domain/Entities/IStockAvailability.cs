using System;
using System.Collections.Generic;
using System.Text;

namespace BTN.Demo.Menu.Domain.Entities
{
    /// <summary>
    /// Interface for Availability property of entity
    /// </summary>
    public interface IStockAvailability
    {
        bool InStock { get; set; } 
    }
}
