using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
	public class Node
	{
		public String question { get;set;}
		public Node left { get; set; }
		public Node right { get; set; }
		//"Node objects have a question, and  left and right pointer to other Nodes"
		public Node(String question, Node left, Node right)
		{
			this.question = question;
			this.left = left;
			this.right = right;
		}
		public Node(String question)
		{
			this.question = question;
		}
		public Node()
		{
			
		}
	}
}