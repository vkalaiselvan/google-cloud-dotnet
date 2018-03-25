﻿/*
    MIT License

    Copyright(c) 2014-2018 Infragistics, Inc.
    Copyright 2018 Google LLC

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

using Xunit;
using BreakingChangesDetector.MetadataItems;

namespace BreakingChangesDetector.UnitTests.MetadataTypesTests
{

    public class ParameterCollectionTests
    {
        #region RequiredArgumentCount

        [Fact]
        public void RequiredArgumentCount()
        {
            var t = typeof(VariousMemberFeatures);
            var context = MetadataResolutionContext.CreateFromTypes(t);
            var typeData = context.GetTypeDefinitionData(t);

            var method = (MethodData)typeData.GetMember("MethodWithDefaultParameter");
            AssertX.Equal(1, method.Parameters.RequiredArgumentCount, "The RequiredArgumentCount of the parameters collection is not correct.");

            method = (MethodData)typeData.GetMember("MethodWithParameterModifiers");
            AssertX.Equal(3, method.Parameters.RequiredArgumentCount, "The RequiredArgumentCount of the parameters collection is not correct.");

            method = (MethodData)typeData.GetMember("MethodWithParameterTypes");
            AssertX.Equal(2, method.Parameters.RequiredArgumentCount, "The RequiredArgumentCount of the parameters collection is not correct.");

            method = (MethodData)typeData.GetMember("MethodWithParamsArray");
            AssertX.Equal(1, method.Parameters.RequiredArgumentCount, "The RequiredArgumentCount of the parameters collection is not correct.");
        }

        #endregion // RequiredArgumentCount
    }
}