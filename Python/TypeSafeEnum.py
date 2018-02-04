import xlrd

#Constants
TemplatePath = 'Templates/'
TemplateFileName = 'TypeSafeEnumTemplate.txt'
TemplateLine = '\tpublic static readonly %s %s = new %s("%s");\n'

OutputFileNameExtension = ".cs"

def Create(path, page, output, scriptName, horizontal):
	wb = xlrd.open_workbook(path)
# Open the workbook and select the first worksheet
	sh = wb.sheet_by_index(page)

	enumOuput = ''
	if horizontal:
		for col in range(0, sh.ncols):
			value = sh.cell(0, col).value
			if value == '':
				continue
			enumOuput += TemplateLine % (scriptName, value, scriptName, value)
	else:
		for row in range(0, sh.nrows):
			value = sh.cell(row, 0).value
			if value == '':
				continue
			enumOuput += TemplateLine % (scriptName, value, scriptName, value)

	with open(TemplatePath + TemplateFileName, 'r') as f:
		fileOutput = f.read() % (scriptName, enumOuput, scriptName)

	# Write to file
	with open('../' + output + scriptName + OutputFileNameExtension, 'w') as f:
	    f.write(fileOutput)
