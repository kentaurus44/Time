import xlrd

#Constants
TemplatePath = 'Templates/'
TemplateFileName = 'EnumTemplate.txt'
TemplateLine = '\t%s'
TemplateEndOfLine = ',\n'
OutputFileNameExtension = ".cs"

def Create(path, page, output, scriptName, enumName, horizontal):
	wb = xlrd.open_workbook(path)
# Open the workbook and select the first worksheet
	sh = wb.sheet_by_index(page)

	enumOuput = ''
	if horizontal:
		for col in range(0, sh.ncols):
			value = sh.cell(0, col).value
			if value == '':
				continue
			enumOuput += TemplateLine % (value)
			if col < sh.ncols - 1:
				enumOuput += TemplateEndOfLine
	else:
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