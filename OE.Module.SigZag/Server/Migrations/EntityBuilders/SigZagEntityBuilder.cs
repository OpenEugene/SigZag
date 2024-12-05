using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace OE.Module.SigZag.Migrations.EntityBuilders
{
    public class SigZagEntityBuilder : AuditableBaseEntityBuilder<SigZagEntityBuilder>
    {
        private const string _entityTableName = "OESigZag";
        private readonly PrimaryKey<SigZagEntityBuilder> _primaryKey = new("PK_OESigZag", x => x.SigZagId);
        private readonly ForeignKey<SigZagEntityBuilder> _moduleForeignKey = new("FK_OESigZag_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public SigZagEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override SigZagEntityBuilder BuildTable(ColumnsBuilder table)
        {
            SigZagId = AddAutoIncrementColumn(table,"SigZagId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> SigZagId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
