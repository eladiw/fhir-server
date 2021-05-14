﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using Microsoft.Health.Fhir.SqlServer.Features.Schema.Model;
using Microsoft.Health.Fhir.SqlServer.Features.Storage;
using Microsoft.Health.SqlServer.Features.Schema.Model;

namespace Microsoft.Health.Fhir.SqlServer.Features.Operations.Import.DataGenerator
{
    internal class TokenDateTimeCompositeSearchParamsTableBulkCopyDataGenerator : SearchParamtersTableBulkCopyDataGenerator
    {
        private ITableValuedParameterRowGenerator<ResourceMetadata, TokenDateTimeCompositeSearchParamTableTypeV1Row> _searchParamGenerator;

        public TokenDateTimeCompositeSearchParamsTableBulkCopyDataGenerator(ITableValuedParameterRowGenerator<ResourceMetadata, TokenDateTimeCompositeSearchParamTableTypeV1Row> searchParamGenerator)
        {
            _searchParamGenerator = searchParamGenerator;
        }

        internal override string TableName
        {
            get
            {
                return VLatest.TokenDateTimeCompositeSearchParam.TableName;
            }
        }

        internal override void FillDataTable(DataTable table, SqlBulkCopyDataWrapper input)
        {
            IEnumerable<TokenDateTimeCompositeSearchParamTableTypeV1Row> searchParams = _searchParamGenerator.GenerateRows(input.Metadata);

            foreach (TokenDateTimeCompositeSearchParamTableTypeV1Row searchParam in searchParams)
            {
                FillDataTable(table, input.ResourceTypeId, input.ResourceSurrogateId, searchParam);
            }
        }

        internal static void FillDataTable(DataTable table, short resourceTypeId, long resourceSurrogateId, TokenDateTimeCompositeSearchParamTableTypeV1Row searchParam)
        {
            DataRow newRow = CreateNewRowWithCommonProperties(table, resourceTypeId, resourceSurrogateId, searchParam.SearchParamId);

            FillColumn(newRow, VLatest.TokenDateTimeCompositeSearchParam.SystemId1.Metadata.Name, searchParam.SystemId1);
            FillColumn(newRow, VLatest.TokenDateTimeCompositeSearchParam.Code1.Metadata.Name, searchParam.Code1);
            FillColumn(newRow, VLatest.TokenDateTimeCompositeSearchParam.StartDateTime2.Metadata.Name, searchParam.StartDateTime2.DateTime);
            FillColumn(newRow, VLatest.TokenDateTimeCompositeSearchParam.EndDateTime2.Metadata.Name, searchParam.EndDateTime2.DateTime);
            FillColumn(newRow, VLatest.TokenDateTimeCompositeSearchParam.IsLongerThanADay2.Metadata.Name, searchParam.IsLongerThanADay2);

            table.Rows.Add(newRow);
        }

        internal override void FillSearchParamsSchema(DataTable table)
        {
            table.Columns.Add(new DataColumn(VLatest.TokenDateTimeCompositeSearchParam.SystemId1.Metadata.Name, VLatest.TokenDateTimeCompositeSearchParam.SystemId1.Metadata.SqlDbType.GetGeneralType()));
            table.Columns.Add(new DataColumn(VLatest.TokenDateTimeCompositeSearchParam.Code1.Metadata.Name, VLatest.TokenDateTimeCompositeSearchParam.Code1.Metadata.SqlDbType.GetGeneralType()));
            table.Columns.Add(new DataColumn(VLatest.TokenDateTimeCompositeSearchParam.StartDateTime2.Metadata.Name, VLatest.TokenDateTimeCompositeSearchParam.StartDateTime2.Metadata.SqlDbType.GetGeneralType()));
            table.Columns.Add(new DataColumn(VLatest.TokenDateTimeCompositeSearchParam.EndDateTime2.Metadata.Name, VLatest.TokenDateTimeCompositeSearchParam.EndDateTime2.Metadata.SqlDbType.GetGeneralType()));
            table.Columns.Add(new DataColumn(VLatest.TokenDateTimeCompositeSearchParam.IsLongerThanADay2.Metadata.Name, VLatest.TokenDateTimeCompositeSearchParam.IsLongerThanADay2.Metadata.SqlDbType.GetGeneralType()));
        }
    }
}