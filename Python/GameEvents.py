import xlrd
from collections import OrderedDict
import simplejson as json

#Constants
EventNameKey = 'EventName'
EventRequirementsKey = 'Requirements'
EventContainerKey = 'Events'

EventOutputFileName = 'Events.json'

#Columns
EventName = 0
EventRequirements = 1

def Export(path, page, output):
	wb = xlrd.open_workbook(path)
# Open the workbook and select the first worksheet
	sh = wb.sheet_by_index(page)

	events = []

	for row in range(1, sh.nrows):
		#create
		event = OrderedDict()

		#get eventName
		event[EventNameKey] = sh.cell(row, EventName).value

		#get requiremnts
		event[EventRequirementsKey] = [];
		for col in range(EventRequirements, sh.ncols):
			value = sh.cell(row, col).value
			if not value:
				break;
			event[EventRequirementsKey].append(value)

		events.append(event)

	gameEvents = OrderedDict()
	gameEvents[EventContainerKey] = events

	# Serialize the list of dicts to JSON
	j = json.dumps(gameEvents, sort_keys=True, indent=4)

	# Write to file
	with open('../' + output + EventOutputFileName, 'w') as f:
	    f.write(j)