import xlrd
from collections import OrderedDict
import simplejson as json

#Constants
DialogInteractingObjectKey = 'InteractingObject'
DialogNameKey = 'EventName'
DialogFirstKey = 'First'
DialogRepeatKey = 'Repeat'
DialogContainerKey = 'Dialogs'

DialogOutputFileName = 'Dialogues.json'


#Columns
InteractingObject = 0
EventName = 1
First = 2
Repeat = 3

def Export(path, page, output):
	wb = xlrd.open_workbook(path)
# Open the workbook and select the first worksheet
	sh = wb.sheet_by_index(page)

	dialogs = []

	for row in range(1, sh.nrows):
		#create
		dialog = OrderedDict()

		#get GetColumns
		dialog[DialogInteractingObjectKey] = sh.cell(row, InteractingObject).value
		dialog[DialogNameKey] = sh.cell(row, EventName).value
		dialog[DialogFirstKey] = sh.cell(row, First).value
		dialog[DialogRepeatKey] = sh.cell(row, Repeat).value

		dialogs.append(dialog)

	gameDialogs = OrderedDict()
	gameDialogs[DialogContainerKey] = dialogs

	# Serialize the list of dicts to JSON
	j = json.dumps(gameDialogs, sort_keys=True, indent=4)

	# Write to file
	with open('../' + output + DialogOutputFileName, 'w') as f:
	    f.write(j)