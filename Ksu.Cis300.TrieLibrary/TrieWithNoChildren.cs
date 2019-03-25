/* Filename: TrieWithNoChildren.cs
 * Author: Tyler Braddock
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// Public method TrieWithNoChildren
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Private field telling whether the string cotains the empty string.
        /// </summary>
        private bool _containsMT = false;
       
        /// <summary>
        /// A public method to Add a given string s to the Trie.
        /// </summary>
        /// <param name="s">string to be added</param>
        /// <returns>returns the trie with the string added to it</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _containsMT = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _containsMT);
            }
        }

        /// <summary>
        /// A public method to tell if trie contains the given string s.
        /// </summary>
        /// <param name="s">string to be found in trie</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _containsMT;
            }
            else
            {
                return false;
            }
        }
    }
}
