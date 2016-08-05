﻿using System.Dynamic;
using Xunit;

namespace RazorLight.Tests
{
    public class ModelTypeInfoTest
    {
		[Fact]
	    public void Real_Object_Is_StrongType_True()
	    {
		    var info = new ModelTypeInfo(typeof(TestViewModel));

			Assert.True(info.IsStrongType);
	    }

		[Fact]
	    public void Anonymous_Objects_Has_StrongType_False()
	    {
		    var model = new
		    {
			    Title = "Johny"
		    };

			var info = new ModelTypeInfo(model.GetType());

			Assert.False(info.IsStrongType);
	    }

		[Fact]
	    public void Return_Dynamic_TemplateTypeName_On_AnonymousObjects()
	    {
		    var model = new {Title = "Jogny"};
			var info = new ModelTypeInfo(model.GetType());

		    string expectedTemplateType = "dynamic";

			Assert.Equal(info.TemplateTypeName, expectedTemplateType);
	    }

		[Fact]
	    public void Return_Expando_TemplateType_On_AnonymousObjects()
	    {
		    var model = new {Title = "Johny"};
			var info = new ModelTypeInfo(model.GetType());

			Assert.Equal(info.TemplateType, typeof(ExpandoObject));
	    }

		[Fact]
	    public void Return_Same_Type_On_StrongType()
	    {
		    var info = new ModelTypeInfo(typeof(TestViewModel));

			Assert.Equal(info.TemplateType, typeof(TestViewModel));
	    }
	}
}
