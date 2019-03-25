/* Filename: TrieWithOneChild.cs
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
    /// Public class Triewithonechild
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// A private field storing whether the string contains the empty string.
        /// </summary>
        private bool _containsMT = false;
        /// <summary>
        /// A perivate field storing a child of the Trie
        /// </summary>
        private ITrie _onlyChild = null;
        /// <summary>
        /// A private field storing the label of the child
        /// </summary>
        private char _label;

        /// <summary>
        /// A public method to add a word/string to a trie and return the trie.
        /// </summary>
        /// <param name="s">string to add to trie</param>
        /// <returns></returns>
        public ITrie Add(string s)
        {

            if (s == "")
            {
                _containsMT = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (s[0] == _label)
            {    
                    _onlyChild = _onlyChild.Add(s.Substring(1));
                    return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _containsMT, _label, _onlyChild);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">string to check</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _containsMT;
            }
            else if (s[0] == _label)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A public constructor for a TrieWithOneChld
        /// </summary>
        /// <param name="s">string of word</param>
        /// <param name="hasEmpty">tells if string is empty</param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }

            _containsMT = hasEmpty;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }
    }
}
