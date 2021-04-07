using System.Collections;
using System.Collections.Generic;

namespace WEC_Builder
{
    public class QueryMake
    {
        public static CreateTableQuery CreateTables = new CreateTableQuery();

        public static AlterTableQuery AlterTables = new AlterTableQuery();

        public static CreateIndexQuery CreateIndexs = new CreateIndexQuery();

        public static CreateViewQuery CreateView = new CreateViewQuery();

        public static CreateSPQuery CreateSP = new CreateSPQuery();

        public static InitQuery Initializer = new InitQuery();
    }


}
