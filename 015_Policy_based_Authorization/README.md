# Policy-based Authorization in ASP.NET Core (Yet to be complete)

## Introduction
Policy-based authorization in ASP.NET Core provides a flexible way to control access to resources by defining policies that encapsulate requirements. Unlike role-based authorization, which checks if a user belongs to a specific role, policy-based authorization evaluates multiple criteria through custom requirements and handlers.

## Key Concepts

### Authorization Policy
An authorization policy consists of one or more requirements. When a policy is applied, all requirements must be satisfied for the authorization to succeed.

### Authorization Requirement
An authorization requirement is a collection of data needed to evaluate a user’s authorization status. It is a simple class implementing the `IAuthorizationRequirement` interface.

### Authorization Handler
An authorization handler is responsible for the evaluation of a requirement's logic. It contains the actual code to determine if the requirement is met.

### Example: Minimum Age Policy

In this example, we will create a policy that ensures a user is at least 21 years old.



