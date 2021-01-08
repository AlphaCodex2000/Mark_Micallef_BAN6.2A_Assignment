using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Application.ViewModels;

namespace ShoppingCart.Application.Interfaces
{
    public interface IMemberService
    {
       void AddMember (MemberViewModel m);
    }
}
