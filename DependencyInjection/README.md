# Dependency Injection

Source: https://martinfowler.com/articles/injection.html#InversionOfControl

This technique makes a particular class independent of the implementation of it's given dependencies.
It achieves that by decoupling the usage of an object, from the creation of the object. It is also
described in the SOLID principles for 'dependency injection' ('inversion of control'). It is an alternative
to the 'service locator' pattern. We will cover that in a follow-up.

A good way to see this is to picture a way to provide a plug-in like experience for other services.
Each of the other teams would be responsible for building their own plug-in to actually work with the
object, and the object itself remains completely independent of the implementation of such plug-in.
This is achieved by using interfaces.


# The solutions

There are a total of three files within this project.

* NaiveImplementation: This file basically shows the core of the problem, which would be by 
creating a concrete class for our Interface, making our 'target class' decoupled for the new methods
you might add, but tightly coupled to the concrete implementation of the interface, and thus loosing
flexibility.

* NaiveImplementation: This file basically shows the problem that we're trying to solve, which is
create a solution that works for any given mehtod of storage that a particular client might be using
for storing movies. Naively, in this example we thought that using the IMovieFinder interface as a 
property within our MovieLister class would be enough. But then on the constructor we are using a
concrete class for creating our MovieLister. This makes MovieLister and the ColonDelimitedMovieFinder
tightly coupled. Any other client that wants to do this would then need to re-create the MovieLister
class to make things work if they are using something different than colon delimited files.

* The ConstructorInjection.cs demonstrates the way we can inject interfaces using the constructor
method of a given class. All of the other methods remain unchanged, and therefore our code is now
independent of the actual implementation of the IMovieFinder interface - This can be, for the given
example, a ColonDelimitedMovieFinder, that knows how to parse colon delimited files. In other
examples this can be for example, querying a database, or parsing XML files.

The thing to note here is that the concrete class needs to be passed on yet another configuration class.

* InterfaceInjection.cs demonstrates the usate of injection of dependencies using interfaces. In this 
case, we can see that our MovieLister class implements the IInjectFinder interface. This interface
implements a method to add the IMovieFinder concrete implementation to the MovieLister. This can be
ColonDelimitedMovieFinder. Similarly, we demonstrate that on the ColonDelimitedMovieFinder, we're also
injecting a dependency for the filename by using a the IInjectFinderFilename interface to add extra
dependencies.

The container uses the declared injection interfaces to figure out the dependencies and the injectors to 
inject the correct dependents.

