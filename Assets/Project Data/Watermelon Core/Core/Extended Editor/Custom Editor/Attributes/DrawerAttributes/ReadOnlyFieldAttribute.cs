﻿using System;

namespace Watermelon
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReadOnlyFieldAttribute : DrawerAttribute
    {
    }
}
