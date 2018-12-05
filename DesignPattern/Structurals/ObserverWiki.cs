using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace wiki.Observer
{
	// IObserver --> interface for the observer
	public interface IObserver
	{
		// called by the subject to update the observer of any change
		// The method parameters can be modified to fit certain criteria
		void Update(string message);
	}

	public class Subject
	{
		// use array list implementation for collection of observers
		private ArrayList observers;

		// constructor
		public Subject()
		{
			observers = new ArrayList();
		}

		public void Register(IObserver observer)
		{
			// if list does not contain observer, add
			if (!observers.Contains(observer))
			{
				observers.Add(observer);
			}
		}

		public void Deregister(IObserver observer)
		{
			// if observer is in the list, remove
			if (observers.Contains(observer))
			{
				observers.Remove(observer);
			}
		}

		public void Notify(string message)
		{
			// call update method for every observer
			foreach (IObserver observer in observers)
			{
				observer.Update(message);
			}
		}
	}

	// Observer1 --> Implements the IObserver
	public class Observer1 : IObserver
	{
		public void Update(string message)
		{
			Debug.WriteLine("Observer1 get " + message);
		}
	}

	// Observer2 --> Implements the IObserver
	public class Observer2 : IObserver
	{
		public void Update(string message)
		{
			Debug.WriteLine("Observer2 get " + message);
		}
	}    
}