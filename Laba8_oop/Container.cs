using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8_oop
{
	public class Node
	{
		public Shape key;
		public Node next = null;
		public Node prev = null;
	}

	public class Container : IObserver, ISubject
	{
		Node head = null;
		Node back = null;
		Node endNode = new Node();

		int count = 0;

		private List<IObserver> observers = new List<IObserver>();

		public void addObserver(IObserver observer)
		{
			observers.Add(observer);
		}

		public void removeObserver(IObserver observer)
		{
			observers.Remove(observer);
		}

		public void notifyEveryone()
		{
			for (int i = 0; i < observers.Count(); ++i)
			{
				observers[i].onSubjectChanged(this);
			}
		}

		public void onSubjectChanged(ISubject subject)
		{
			if (subject is CustomTreeView)
			{
				Node current = head;
				while (current != endNode)
				{
					Shape shape = current.key;
					if (shape.getID() == (subject as CustomTreeView).selectedNode)
					{
						break;
					}
					else
					{
						if (shape is CGroup)
						{
							Node result;
							if (((shape as CGroup).getShapes().Contains((subject as CustomTreeView).selectedNode)) == true)
							{

								break;
							}
						}
					}


					current = current.next;
				}


				if (current != null)
				{
					Shape shape = current.key;
					bool tmp = shape.getGroupFlag();
					shape.setGroupFlag(true);
					shape.setMarked((shape.getMarked() == true ? false : true));
					shape.setGroupFlag(tmp);
				}
				return;
			}

			notifyEveryone();

		}

		private void readingShapes(StreamReader reader, ShapeFactory factory)
		{
			string line;
			while ((line = reader.ReadLine()) != null && line != "")
			{
				char code = line[0];
				Shape shape = factory.createShape(code);

				if (shape != null)
				{
					if (shape is CGroup)
					{
						(shape as CGroup).loadGroup(reader, factory);
						Push_back(shape);
						continue;
					}

					shape.load(reader);
					Push_back(shape);
				}
				else
				{
					return;
				}
			}
		}

		public void loadShapes(string pathToTheFile, ShapeFactory factory)
		{
			using (StreamReader reader = new StreamReader(pathToTheFile, System.Text.Encoding.Default))
			{
				readingShapes(reader, factory);
			}
			notifyEveryone();
		}

		public void loadShapes(StreamReader reader, ShapeFactory factory)
		{
			readingShapes(reader, factory);
		}

		public void saveShapes(string pathToTheFile)
		{
			if (count != 0)
			{
				using (StreamWriter writer = new StreamWriter(pathToTheFile, false, System.Text.Encoding.Default))
				{
					Node current = head;
					while (current != endNode)
					{
						current.key.save(writer);
						current = current.next;
					}
				}
			}

		}

		private void updateBackNEnd()
		{


			if (head == endNode)
			{
				head = null;
				back = null;
				endNode.next = endNode.prev = null;
			}

			if (endNode.prev == null)
			{
				if (head != null)
				{
					back = head;
					back.next = endNode;
					endNode.prev = back;
				}
			}

			if (back != endNode.prev)
			{
				back = endNode.prev;
			}

			notifyEveryone();
		}

		public Container()
		{

		}

		public Container(Shape newItem)
		{
			head = new Node();
			head.key = newItem;

			updateBackNEnd();
		}

		public int Count()
		{
			return count;
		}

		public Node Search(Shape item)
		{
			Node node = head;
			while (node != null && node.next != endNode && node.key != item)
			{
				node = node.next;
			}

			if (node != null && node.next == endNode && node.key != item)
			{
				return null;
			}

			return node;
		}

		public bool Contains(int id)
		{
			Node node = head;
			while (node != null && node.next != endNode && node.key.getID() != id)
			{
				if (node.key is CGroup)
				{
					bool result = (node.key as CGroup).getShapes().Contains(id);
					if (result)
					{
						return true;
					}
				}
				node = node.next;
			}

			if (node != null && node.next == endNode && node.key.getID() != id)
			{
				if (node.key is CGroup)
				{
					return (node.key as CGroup).getShapes().Contains(id);

				}
				return false;
			}

			return true;
		}

		public void Insert(Shape newItem)
		{
			if (newItem is StickyRectangle)
			{
				addObserver(newItem);
			}

			newItem.addObserver(this);
			Node newNode = new Node();
			newNode.key = newItem;
			count++;

			newNode.next = head;
			if (head != null)
			{
				head.prev = newNode;
				newNode.next = head;
			}
			head = newNode;

			updateBackNEnd();
		}

		public void Push_back(Shape newItem)
		{
			Node newNode = new Node();
			newNode.key = newItem;

			if (head == null)
			{
				Insert(newItem);
			}
			else
			{
				if (newItem is StickyRectangle)
				{
					addObserver(newItem);
				}
				newItem.addObserver(this);
				count++;
				newNode.prev = back;
				back.next = newNode;
				back = newNode;
				newNode.next = endNode;
				endNode.prev = newNode;
				updateBackNEnd();
			}
		}

		public bool Remove(Shape item)
		{
			Node nodeToRemove;
			nodeToRemove = Search(item);

			if (nodeToRemove != null)
			{
				count--;
				if (nodeToRemove.prev != null)
				{
					nodeToRemove.prev.next = nodeToRemove.next;
				}
				else
				{
					head = nodeToRemove.next;
				}

				if (nodeToRemove.next != null)
				{
					nodeToRemove.next.prev = nodeToRemove.prev;
				}

				updateBackNEnd();
				return true;
			}

			updateBackNEnd();
			return false;
		}

		public ContainerIterator Begin()
		{
			if (head != null)
			{
				ContainerIterator beginIterator = new ContainerIterator(head);
				return beginIterator;
			}
			else
			{
				ContainerIterator beginIterator = new ContainerIterator(endNode);
				return beginIterator;
			}
		}

		public ContainerIterator Last()
		{
			if (back != null)
			{
				ContainerIterator beginIterator = new ContainerIterator(back);
				return beginIterator;
			}
			else
			{
				ContainerIterator beginIterator = new ContainerIterator(endNode);
				return beginIterator;
			}
		}

		public ContainerIterator End()
		{
			ContainerIterator endIterator = new ContainerIterator(endNode);
			return endIterator;
		}


	}

	public class ContainerIterator
	{
		Node currentNode = null;

		public ContainerIterator()
		{

		}

		public ContainerIterator(Node node)
		{
			currentNode = node;
		}

		public static ContainerIterator operator ++(ContainerIterator obj)
		{
			obj.currentNode = obj.currentNode.next;
			return obj;
		}

		public static ContainerIterator operator --(ContainerIterator it)
		{
			it.currentNode = it.currentNode.prev;
			return it;
		}

		public static bool operator ==(ContainerIterator it1, ContainerIterator it2)
		{
			return (it1.currentNode == it2.currentNode ? true : false);
		}

		public static bool operator !=(ContainerIterator it1, ContainerIterator it2)
		{
			return (it1.currentNode != it2.currentNode ? true : false);
		}

		public Node getNode()
		{
			return currentNode;
		}

	}
}
