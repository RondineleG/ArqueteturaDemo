using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Browl.Infrastructure.Extension
{
    public static class ModelBuilderExtension
    {
        public static string GetColumnName(this PropertyEntry propertyEntry)
        {
            var storeObjectId =
                       StoreObjectIdentifier.Create(propertyEntry.Metadata.DeclaringEntityType, StoreObjectType.Table);

            return propertyEntry.Metadata.GetColumnName(storeObjectId.GetValueOrDefault()).StringToLowerCaseName();
        }

        public static void ToLowerCaseName(this ModelBuilder modelBuilder)
        {

            foreach(var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName().StringToLowerCaseName();
                entity.SetTableName(tableName);



                foreach(var property in entity.GetProperties())
                {
                    var columnName = property.GetColumnName().StringToLowerCaseName();
                    property.SetColumnName(columnName);
                }

                foreach(var key in entity.GetKeys())
                {
                    var keyName = key.GetName().StringToLowerCaseName();
                    key.SetName(keyName);
                }

                foreach(var key in entity.GetForeignKeys())
                {
                    var foreignKeyName = key.GetConstraintName().StringToLowerCaseName();
                    key.SetConstraintName(foreignKeyName);
                }

                foreach(var index in entity.GetIndexes())
                {
                    var indexName = index.GetDatabaseName().StringToLowerCaseName();
                    index.SetDatabaseName(indexName);
                }

            }

        }

        private static string StringToLowerCaseName(this string name) => string.IsNullOrWhiteSpace(name) ? name : name.ToLower();
    }
}
