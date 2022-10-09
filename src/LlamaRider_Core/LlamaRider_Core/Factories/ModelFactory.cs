using System.Reflection;

namespace DataImport.Factories;


public class ModelFactory<TModelType> 
	where TModelType : class, new()
{
	public TModelType Get(
		Dictionary<string, object>? param = null)
	{
		if (param == null)
		{
			param = new Dictionary<string, object>();
		}

		PropertyInfo[] properties = this.GetType().GetProperties();
		TModelType factoriedObj = new TModelType();
		
		foreach (PropertyInfo property in properties)
		{
			PropertyInfo modelProperty = typeof(TModelType)
				.GetProperty(name: property.Name)!;
			
			if (param.ContainsKey(property.Name) == false)
			{
				modelProperty.SetValue(
					obj: factoriedObj,
					value: Convert.ChangeType(
						value: property.GetValue(obj: this),
						conversionType: modelProperty.PropertyType));
			}
			else
			{
				modelProperty.SetValue(
					obj: factoriedObj,
					value: Convert.ChangeType(
						value: param[property.Name], 
						conversionType: modelProperty.PropertyType));
			}
		}
     
		return (factoriedObj);
	}
}
