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
    internal class NumberSearchParamsTableBulkCopyDataGenerator : SearchParamtersTableBulkCopyDataGenerator
    {
        private ITableValuedParameterRowGenerator<ResourceMetadata, NumberSearchParamTableTypeV1Row> _searchParamGenerator;

        public NumberSearchParamsTableBulkCopyDataGenerator(ITableValuedParameterRowGenerator<ResourceMetadata, NumberSearchParamTableTypeV1Row> searchParamGenerator)
        {
            _searchParamGenerator = searchParamGenerator;
        }

        internal override string TableName
        {
            get
            {
                return VLatest.NumberSearchParam.TableName;
            }
        }

        internal override void FillDataTable(DataTable table, SqlBulkCopyDataWrapper input)
        {
            IEnumerable<NumberSearchParamTableTypeV1Row> searchParams = _searchParamGenerator.GenerateRows(input.Metadata);

            foreach (NumberSearchParamTableTypeV1Row searchParam in searchParams)
            {
                DataRow newRow = CreateNewRowWithCommonProperties(table, input.ResourceTypeId, input.ResourceSurrogateId, searchParam.SearchParamId);
                newRow[VLatest.NumberSearchParam.SingleValue.Metadata.Name] = searchParam.SingleValue;
                newRow[VLatest.NumberSearchParam.LowValue.Metadata.Name] = searchParam.LowValue;
                newRow[VLatest.NumberSearchParam.HighValue.Metadata.Name] = searchParam.HighValue;

                table.Rows.Add(newRow);
            }
        }

        internal override void FillSearchParamsSchema(DataTable table)
        {
            table.Columns.Add(new DataColumn(VLatest.NumberSearchParam.SingleValue.Metadata.Name, VLatest.NumberSearchParam.SingleValue.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.NumberSearchParam.LowValue.Metadata.Name, VLatest.NumberSearchParam.LowValue.Metadata.Type));
            table.Columns.Add(new DataColumn(VLatest.NumberSearchParam.HighValue.Metadata.Name, VLatest.NumberSearchParam.HighValue.Metadata.Type));
        }
    }
}
