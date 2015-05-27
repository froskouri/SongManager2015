using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using SongManager.DataAccess;

namespace SongManager.DataAccess.Migrations
{
    [ContextType(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("SongManager.DataAccess.Song", b =>
                    {
                        b.Property<string>("Artist")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<Guid>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 2);
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}
