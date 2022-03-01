## Monkey validator => a Linq approach to validation

This library aims at making validation easy, fluent and versatile.

## Types of Validation

### On The Fly
Use this type of validation anywhere in your code. Just called the `GetValidator()` on any object and start chaining your validation.

![on the fly](https://user-images.githubusercontent.com/81313844/155906411-e0778431-a097-436c-a055-6b96f56fc32f.jpg)

### Reusable
Create an ad-hoc validator class inheriting from `CustomMonkeyValidatorBase<T>` and build your validator in the abstract `SetupValidator()` method.

![Reusable](https://user-images.githubusercontent.com/81313844/155906175-2eb5562d-5256-4781-829a-9fdc58abcd4c.png)

validators can be chained, and the validation will pickup all errors before throwing.

![MultiChaining](https://user-images.githubusercontent.com/81313844/155907326-d66381e7-140f-4074-a21d-ddcb7cc25c3b.jpg)

## Conditional Validation

You can use an if/else if/else logic for more complex scenarios

![ConditionalValidationExample](https://user-images.githubusercontent.com/81313844/155906485-47fc448b-38a5-4493-962f-0bb5003a5f4f.png)

## Fail Fast

If you want to break the validation if a certain condition is met, you can use the `FailFastIf()` extension, which will throw immediatelly if the predicate returns false.

![failfast](https://user-images.githubusercontent.com/81313844/155906635-1b5d8066-9aa0-4fdd-8acc-cff656c5ce12.jpg)

## Custom On Fail

If you want to insert your own logic on validation failure, you can use the overload that takes an `Action<List<string>>` where `List<string>` are the validation errors.

![155908647-ed83b6f7-e41c-4529-9191-fca65e934f8c](https://user-images.githubusercontent.com/81313844/155911582-3ccc1d73-73eb-4c7f-a70d-21e1eecd8efa.jpg)

You can set the optional `throwMonkeyException` flag to `true` if you just want to add some logic before the default exception is thrown.

![CustomResult](https://user-images.githubusercontent.com/81313844/155909081-5568fb34-49c2-489b-8ad6-15dbf1012f38.jpg)

## Custom Rules

For on the fly, one time only custom rules, you can simply chain a `CustomRule()` and pass in your predicate.

![155909572-eb2a1cf9-5a9b-4c10-8dd0-9e8c1aef49f3](https://user-images.githubusercontent.com/81313844/155911573-94a29b0b-59ed-44f6-9f26-d83741f9b95f.jpg)

For rules you want to reuse, but are not specific enough to put on a Validator class, I'd recommend creating a static class to extend the `MonkeyValidator<T>` with your rule fragments:

![155909683-61bad9ca-f50e-49dc-b4f8-92f702faef94](https://user-images.githubusercontent.com/81313844/155911550-6c2dd244-ec93-4314-9fd3-73add0e2cf26.jpg)

which you can then chain to your other validators.

![CustomResult](https://user-images.githubusercontent.com/81313844/155909848-fc6479f2-f82a-4fd9-a9a1-e8b5743533dc.jpg)

## Injectable Validation

Sometimes, validation can hinder testability. A complex validator can become rather troublesome for testers, especially for testing edge cases where the validation has little to no bearing to the section of code being tested.

We can circumvent the issue by creating an injectable service like so:

![injectable validation](https://user-images.githubusercontent.com/81313844/156066301-0b0ec936-d2c7-45a8-8b74-5b029c2c1af0.jpg)

This has the added advantage that if we need to inject other services that are required to fulfil our validation, those are encapsulated in the IStringValidator, and thus not required when unit testing. The IStringValidator can then be reused to add all the validation methods related to strings.
