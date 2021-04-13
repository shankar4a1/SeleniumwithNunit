using MeridianApp.Models;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp.Utils
{
    public class InputReader
    {
        private IWorkbook workbook;
        private DataFormatter dataFormatter;
        private IFormulaEvaluator formulaEvaluator;
        private Participant participant;

        //
        // Initialize from a stream of Excel file
        //
        private void Init()
        {
            var inputPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\Input\\Input.xlsx";
            this.workbook = WorkbookFactory.Create(new FileStream(inputPath, FileMode.Open, FileAccess.Read));
            if (this.workbook != null)
            {
                this.dataFormatter = new DataFormatter(CultureInfo.InvariantCulture);
                this.formulaEvaluator = WorkbookFactory.CreateFormulaEvaluator(this.workbook);
            }
        }

        public Participant Read(int sampleNo)
        {            
            try
            {
                Init();
                var sheet = workbook.GetSheetAt(0);

                Participant.Id Id = new Participant.Id();
                foreach (IRow row in sheet)
                {
                    var attrib = row.GetCell(1).StringCellValue.ToUpper();
                    var value = GetUnformattedValue(row.GetCell(2 + sampleNo));

                    switch (row.GetCell(1).StringCellValue.ToUpper())
                    {
                        case "IDENTIFICATION":
                            
                            if (attrib == "NAME")
                            {
                                Id.Name = value;
                            }else if(attrib == "COUNTRY OF RESIDENCE")
                            {                                
                                Id.CountryOfResidence = value;
                            }
                            
                            break;

                        case "PHYSICAL ADDRESS":
                            break;
                        case "POSTAL ADDRESS":
                            break;
                        case "CONTACTS":
                            break;
                        case "EXTERNAL SYSTEMS REFERENCES":
                            break;
                        case "NOTES":
                            break;
                        case "BANKING DETAILS":
                            break;
                        case "BILLING PRACTICE DETAILS":
                            break;
                        case "PENALTY GRACE PERIOD":
                            break;
                        case "PENALTY GRACE PERIOD (FOR GUARANTOR)":
                            break;
                        case "BUSINESS DAY CONVENTION":
                            break;
                        case "ISSUER PRACTICES":
                            break;
                        case "CREDIT LIMIT":
                            break;
                        case "CREDIT RATINGS":
                            break;
                    }
                }
                

                participant = new Participant();
                participant._Id = Id;
                //participant._PhysicalAddress = 

                return participant;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Reading Input Excel file");
                throw (ex);
            }
        }


        //
        // Get formatted value as string from the specified cell
        //
        protected string GetFormattedValue(ICell cell)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                try
                {
                    // Get evaluated and formatted cell value
                    returnValue = this.dataFormatter.FormatCellValue(cell, this.formulaEvaluator);
                }
                catch
                {
                    // When failed in evaluating the formula, use stored values instead...
                    // and set cell value for reference from formulae in other cells...
                    if (cell.CellType == CellType.Formula)
                    {
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                cell.SetCellValue(cell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                returnValue = dataFormatter.FormatRawCellContents(cell.NumericCellValue, 0, cell.CellStyle.GetDataFormatString());
                                cell.SetCellValue(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                returnValue = cell.BooleanCellValue.ToString();
                                cell.SetCellValue(cell.BooleanCellValue);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return (returnValue ?? string.Empty).Trim();
        }

        //
        // Get unformatted value as string from the specified cell
        //
        protected string GetUnformattedValue(ICell cell)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                try
                {
                    // Get evaluated cell value
                    returnValue = (cell.CellType == CellType.Numeric ||
                    (cell.CellType == CellType.Formula &&
                    cell.CachedFormulaResultType == CellType.Numeric)) ?
                        formulaEvaluator.EvaluateInCell(cell).NumericCellValue.ToString() :
                        this.dataFormatter.FormatCellValue(cell, this.formulaEvaluator);
                }
                catch
                {
                    // When failed in evaluating the formula, use stored values instead...
                    // and set cell value for reference from formulae in other cells...
                    if (cell.CellType == CellType.Formula)
                    {
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                cell.SetCellValue(cell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                returnValue = cell.NumericCellValue.ToString();
                                cell.SetCellValue(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                returnValue = cell.BooleanCellValue.ToString();
                                cell.SetCellValue(cell.BooleanCellValue);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return (returnValue ?? string.Empty).Trim();
        }
    }
}



