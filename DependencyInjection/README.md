# Dependency Injection

Taken from: https://martinfowler.com/articles/injection.html#UsingAServiceLocator

This technique makes a particular class independent of the implementation of it's given dependencies.
It achieves that by decoupling the usage of an object, from the creation of the object. It is also
described in the SOLID principles for 'dependency injection' ('inversion of control'). It is an alternative
to the 'service locator' pattern. We will cover that in a follow-up.

A good way to see this is to picture a way to provide a plug-in like experience for other services.
Each of the other teams would be responsible for building their own plug-in to actually work with the
object, and the object itself remains completely independent of the implementation of such plug-in.


