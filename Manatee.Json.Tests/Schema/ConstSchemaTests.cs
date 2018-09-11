﻿using System.Linq;
using Manatee.Json.Schema;
using NUnit.Framework;

namespace Manatee.Json.Tests.Schema
{
	[TestFixture]
	public class ConstSchemaTests
	{
		[Test]
		public void ValidationFails()
		{
			var schema = new JsonSchema().Const(5);

			JsonValue json = 6;

			var results = schema.Validate(json);

			Assert.IsFalse(results.IsValid);
			Assert.AreEqual("Expected: 5; Actual: 6", results.Errors.First().Message);
		}

		[Test]
		public void ValidationPasses()
		{
			var schema = new JsonSchema().Const(5);

			JsonValue json = 5;

			var results = schema.Validate(json);

			Assert.IsTrue(results.IsValid);
		}
	}
}
