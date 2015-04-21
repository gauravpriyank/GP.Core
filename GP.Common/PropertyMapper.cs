using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmitMapper;
using EmitMapper.MappingConfiguration;

namespace GP.Common
{
   public  class PropertyMapper<TFrom,TTo>
    {
       public static TTo Map(TFrom mappingObject)
       {
            return ObjectMapperManager.DefaultInstance
                                        .GetMapper<TFrom, TTo>(new DefaultMapConfig().MatchMembers((a, b) => a.Replace("_", "").ToUpper() == b.Replace("_", "").ToUpper()))
                                        .Map(mappingObject);
       }
    }
}
