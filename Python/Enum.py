import xlrd

#Constants
TemplatePath = 'Templates/'
TemplateFileName = 'EnumTemplate.txt'
TemplateLine = '\t%s'
TemplateEndOfLine = ',\n'
OutputFileNameExtension = ".cs"

def Create(path, page, output, scriptName, enumName):
	wb = xlrd.open_workbook(path)
# Open the workbook and select the first worksheet
	sh = wb.sheet_by_index(page)

	enumOuput = ''

	for row in range(0, sh.nrows):
		value = sh.cell(row, 0).value
		if value == '':
			continue
		enumOuput += TemplateLine % (value)
		if row < sh.nrows - 1:
			enumOuput += TemplateEndOfLine

	with open(TemplatePath + TemplateFileName, 'r') as f:
		fileOutput = f.read() % (enumName, enumOuput)

	# Write to file
	with open('../' + output + scriptName + OutputFileNameExtension, 'w') as f:
	    f.write(fileOutput)