using Dapper;
using System.Reflection;

namespace SurveyDemo.Repositories.Mapper
{
    public class Mapper(Type modelType)
    {
        private readonly List<(string DbName, string BlName)> _columns = new();
        private readonly Type _modelType = modelType;
        private bool isConfirm = false;

        public void Confirm()
        {
            SqlMapper.SetTypeMap(_modelType, new CustomPropertyTypeMap(_modelType, SearchColumn));
            isConfirm = true;
        }

        private PropertyInfo SearchColumn(Type type, string columnName)
        {
            PropertyInfo? property = null;
            foreach (var column in _columns)
            {
                if (column.DbName == columnName)
                {
                    property = type.GetProperty(column.BlName);
                    break;
                }
            }
            return property ?? throw new InvalidOperationException($"No matching mapping for {columnName}");
        }
        public void Map(string dbColumnName, string blColumnName)
        {
            if (!isConfirm)
            {
                _columns.Add((dbColumnName, blColumnName));
            }
        }
    }
}