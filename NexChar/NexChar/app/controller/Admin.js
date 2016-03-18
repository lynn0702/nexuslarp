Ext.define('NexChar.FrontEnd.controller.Admin', {
    extend: 'Ext.app.Controller',
    views: [
        'admin.Navigation'
    ],
    stores: [

    ],
    refs: [{
        selector: '#mainContent',
        ref: 'mainContent'
    }    ],
    init: function () {
        var me = this;

        me.control(
            {
                //'payerslist': {
                //   // afterrender: me.onPayersListAfterRender.bind(me)
                //itemdblclick: me.onMiscRowDblClick.bind(me)
                //},
                //'button[name=addNewPayer]': {
                //    'click': me.createNewPayer
                //},
             
            });
    },
    createfile: function () {
        var year = this.getReportYears();
        var reportYear = year.getValue();
        var isTestFile = this.getIsTestFile().getRawValue();
        var reportMessageDisplay = this.getReportMessageDisplay();
        reportMessageDisplay.setValue('');

        if (reportYear == null || reportYear == '') {
            reportMessageDisplay.setValue('Invalid year.');
            return;
        }

        var myMask = new Ext.LoadMask(this.getMainContent(), { msg: "Processing Request..." });

        var keyPairs = [{ key: 'Year', value: reportYear.toString() }, { key: 'IsTest', value: isTestFile }];


        var batchJob = [{ JobName: 'createirsfile', KeyPairs: keyPairs }];

        var callback = function () {
            myMask.show();

            Ext.Ajax.request({
                url: '/TaxInformationManagement/api/batchjob',
                method: 'POST',
                jsonData: batchJob,
                timeout: 300000 * 5,
                callback: function () {
                    reportMessageDisplay.setValue('IRS File Creation Scheduled.');
                    myMask.hide();
                }
            });
        }.bind(this);

        this.warnBeforeAction('Are you sure you want to generate the IRS Report File for year ' + reportYear + '?', 'Create IRS Report File', callback);

    }
   
});