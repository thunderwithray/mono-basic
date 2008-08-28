//
// NestedTypeCollection.cs
//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Generated by /CodeGen/cecil-gen.rb do not edit
// Fri Mar 30 18:43:57 +0200 2007
//
// (C) 2005 Jb Evain
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace Mono.Cecil {

	using System;
	using System.Collections;

	using Mono.Cecil.Cil;

	public sealed class NestedTypeCollection : CollectionBase, IReflectionVisitable {

		TypeDefinition m_container;

		public TypeDefinition this [int index] {
			get { return List [index] as TypeDefinition; }
			set { List [index] = value; }
		}

		public TypeDefinition Container {
			get { return m_container; }
		}

		public NestedTypeCollection (TypeDefinition container)
		{
			m_container = container;
		}

		public void Add (TypeDefinition value)
		{
			Attach (value);

			List.Add (value);
		}


		public new void Clear ()
		{
			foreach (TypeDefinition item in this)
				Detach (item);

			base.Clear ();
		}

		public bool Contains (TypeDefinition value)
		{
			return List.Contains (value);
		}

		public int IndexOf (TypeDefinition value)
		{
			return List.IndexOf (value);
		}

		public void Insert (int index, TypeDefinition value)
		{
			Attach (value);

			List.Insert (index, value);
		}

		public void Remove (TypeDefinition value)
		{
			List.Remove (value);

			Detach (value);
		}


		public new void RemoveAt (int index)
		{
			TypeDefinition item = this [index];
			Remove (item);
		}

		protected override void OnValidate (object o)
		{
			if (! (o is TypeDefinition))
				throw new ArgumentException ("Must be of type " + typeof (TypeDefinition).FullName);
		}

		void Attach (MemberReference member)
		{
			if (member.DeclaringType != null && m_container != member.DeclaringType)
				throw new ReflectionException ("Member already attached, clone it instead");

			member.DeclaringType = m_container;
		}

		void Detach (MemberReference member)
		{
			member.DeclaringType = null;
		}

		public void Accept (IReflectionVisitor visitor)
		{
			visitor.VisitNestedTypeCollection (this);
		}
	}
}
