using FluentValidation;
using Northwind.Entities.Concrete;

namespace Northwind.Business.ValidationRules.FluentValidation
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(p => p.ProductName).NotEmpty();

			RuleFor(p => p.CategoryId).NotEmpty();

			RuleFor(p => p.UnitPrice).NotEmpty().GreaterThan(0);

			RuleFor(p => p.UnitsInStock).NotEmpty().GreaterThan((short)0);
		}
	}
}