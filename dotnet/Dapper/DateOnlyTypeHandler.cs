using System.Data;
using Dapper;

namespace dotnet.Dapper;

public class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public static readonly SqlMapper.ITypeHandler Default = new DateOnlyTypeHandler();
    
    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.DbType = DbType.String;
        parameter.Value = value.ToString("dd/MM/yyyy");
    }

    public override DateOnly Parse(object value)
    {
        return DateOnly.FromDateTime(DateTime.Parse(value.ToString() ?? throw new InvalidOperationException()));
    }
}