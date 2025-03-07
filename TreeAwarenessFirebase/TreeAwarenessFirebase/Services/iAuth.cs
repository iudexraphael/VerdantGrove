﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TreeAwarenessFirebase.Services
{
    public interface iAuth
    {
        Task<string> LoginWithEmailAndPassword(string email, string password);
        Task<string> SignUpWithEmailAndPassword(string email, string password);

   
        bool SignOut();
        bool IsSignIn();
    }
}
