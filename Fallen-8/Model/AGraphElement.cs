// 
// AGraphElement.cs
//  
// Author:
//       Henning Rauch <Henning@RauchEntwicklung.biz>
// 
// Copyright (c) 2012 Henning Rauch
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;

namespace Fallen8.Model
{
    public abstract class AGraphElement
    {
        protected readonly Int64 _id;
        protected readonly DateTime _creationDate;
        protected DateTime _modificationDate;
        protected IDictionary<long, object> _properties;

        public Boolean GraphElementEquals (IDictionary<long, object> propertiesA, IDictionary<long, object> propertiesB)
        {
            if (propertiesA == null && propertiesB == null) {
                return true;
            }
            
            if (propertiesA != null && propertiesB == null) {
                return false;
            }
            
            if (propertiesA == null && propertiesB != null) {
                return false;
            }
            
            if (propertiesA.Count != propertiesB.Count) {
                return false;
            }
            
            foreach (var aPropertyInA in propertiesA) {
                Object valueOfB;
                if (propertiesB.TryGetValue (aPropertyInA.Key, out valueOfB)) {
                    if (!aPropertyInA.Value.Equals (valueOfB)) {
                        return false;
                    }
                } else {
                    return false;
                }
            }
            
            return true;
        }
    }
}

