namespace Back_prueba.Comun
{
    public class Utilitarios
    {
        public void ConvertirPropiedadesAMayusculas(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = (string)property.GetValue(obj);
                    if (!string.IsNullOrEmpty(value))
                    {
                        property.SetValue(obj, value.ToUpper());
                    }
                }
            }
        }
    }
}
