Query
=======

Queries retreive information from the Domain Model. An IQuery describes the query, an IQueryHandler handles an IQuery and returns an IQueryResult.

## Install

```
Install-Package Bocami.Practices.Query -Source https://www.myget.org/F/bocami/
```

## Usage

Query:
```csharp
public class IsUserNameAvailableQuery : IQuery
{
  public string UserName { get; set;}
}
```

Query Result:
```csharp
public class IsUserNameAvailableQueryResult : IQueryResult
{
  public bool IsUserNameAvailable { get; set;}
}
```

Query Handler:
```csharp
public class IsUserNameAvailableQueryHandler : IQueryHandler<IsUserNameAvailableQuery, IsUserNameAvailableQueryResult>
{
  private readonly IUserNameRepository userNameRepository;
  
  public IsUserNameAvailableQueryHandler(IUserNameRepository userNameRepository)
  {
    if(userNameRepository == null)
      throw new ArgumentNullException("userNameRepository");
      
    this.userNameRepository = userNameRepository;
  }
  
  public IsUserNameAvailableQueryResult Handle(IsUserNameAvailableQuery query) 
  {
    var isUserNameAvailable = userNameRepository.All(userName => userName != query.UserName);
    
    return new IsUserNameAvailableQueryResult
    {
      IsUserNameAvailable = isUserNameAvailable
    };
  }
}
```

## Licence
The MIT License (MIT)

Copyright (c) 2014 Jonatan Pedersen http://www.jonatanpedersen.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
