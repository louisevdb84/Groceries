﻿using Groceries.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.Web.Interfaces
{
    public interface IGroceryItemRepository: IBaseRepository<GroceryItem>
    {
    }
}