﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;
using System.Runtime.InteropServices;
using System.Reflection;

namespace System.Windows.Forms.Tests
{
    public class ApplicationTests
    {
        private readonly object _locker = new object();

        [Fact]
        public void Application_EnableVisualStyles_GetUseVisualStyles_ReturnsTrue()
        {
            lock (_locker)
            {
                Assert.False(Application.UseVisualStyles);

                Application.EnableVisualStyles();
                Assert.True(Application.UseVisualStyles, "New Visual Styles will not be applied on Winforms app. This is a high priority bug and must be looked into");

                // Return UseVisualStyles as it was before.
                PropertyInfo prop = typeof(Application).GetProperty(nameof(Application.UseVisualStyles));
                prop?.SetValue(null, false, BindingFlags.NonPublic | BindingFlags.Static, null, null, null);
            }

            Assert.False(Application.UseVisualStyles);
        }

        [Fact]
        public void Application_OpenForms_Get_ReturnsExpected()
        {
            FormCollection forms = Application.OpenForms;
            Assert.Same(forms, Application.OpenForms);
        }
    }
}
