# CodereTechnicalTest

This is the technical test for Codere.

It's an API in .NET 6, using hexagonal architecture and CQRS with MediatR.
There are Unit Tests for the controllers and endpoints but not for the Application Layer (Commands, Queries) due to lack of time.

Maybe for this kind of Technical Test, hexagonal and CQRS could be some over-enginereed but as the exercise says, there is no limit for this.
I appreciate the oportunity, thank you.

Packages:
- Newtonsoft.Json for json deserializer.
- Swashbuckle for documentation and swagger support.
- Moq, xUnit, FluentAssertions for Unit Tests.
- MediatR to implement CQRS more easily. 
