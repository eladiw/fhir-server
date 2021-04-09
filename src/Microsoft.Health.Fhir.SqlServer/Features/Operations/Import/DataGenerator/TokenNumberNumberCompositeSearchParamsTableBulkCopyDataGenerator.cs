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
    internal class TokenNumberNumberCompositeSearchParamsTableBulkCopyDataGenerator : SearchParamtersTableBulkCopyDataGenerator
    {
        private ITableValuedParameterRowGenerator<ResourceMetadata, TokenNumberNumberCompositeSearchParamTableTypeV1Row> _searchParamGenerator;

        public TokenNumberNumberCompositeSearchParamsTableBulkCopyDataGenerator(ITableValuedParameterRowGenerator<ResourceMetadata, TokenNumberNumberCompositeSearchParamTableTypeV1Row> searchParamGenerator)
        {
            _searchParamGenerator = searchParamGenerator;
        }

        internal override string TableName
        {
            get
            {
                return VLatest.TokenNumberNumberCompositeSearchParam.TableName;
            }
        }

        internal override void FillDataTable(DataTable table, SqlBulkCopyDataWrapper input)
        {
            IEnumerable<TokenNumberNumberCompositeSearchParamTableTypeV1Row> searchParams = _searchParamGenerator.GenerateRows(input.Metadata);

            foreach (TokenNumberNumberCompositeSearchParamTableTypeV1Row searchParam in searchParams)
            {
                DataRow newRow = CreateNewRowWithCommonProperties(table, input.ResourceTypeId, input.ResourceSurrogateId, searchParam.SearchParamId);
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.SystemId1.Metadata.Name] = searchParam.SystemId1;
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.Code1.Metadata.Name] = searchParam.Code1;
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.SingleValue2.Metadata.Name] = searchParam.SingleValue2;
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.LowValue2.Metadata.Name] = searchParam.LowValue2;
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.HighValue2.Metadata.Name] = searchParam.HighValue2;
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.SingleValue3.Metadata.Name] = searchParam.SingleValue3;
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.LowValue3.Metadata.Name] = searchParam.LowValue3;
                newRow[VLatest.TokenNumberNumberCompositeSearchParam.HighValue3.Metadata.Name] = searchParam.HighValue3;

                table.Rows.Add(newRow);
            }
        }

        internal override void FillSearchParamsSchema(DataTable table)
        {
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.SystemId1.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.SystemId1.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.Code1.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.Code1.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.SingleValue2.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.SingleValue2.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.LowValue2.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.LowValue2.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.HighValue2.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.HighValue2.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.SingleValue3.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.SingleValue3.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.LowValue3.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.LowValue3.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.TokenNumberNumberCompositeSearchParam.HighValue3.Metadata.Name, VLatest.TokenNumberNumberCompositeSearchParam.HighValue3.Metadata.Type));
        }
    }
}
