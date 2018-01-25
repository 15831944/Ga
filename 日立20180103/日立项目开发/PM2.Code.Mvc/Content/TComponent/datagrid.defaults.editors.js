$.extend($.fn.datagrid.defaults.editors, {

    textbox: {
        init: function (container, options) {
            var input = $('<input>').appendTo(container);
            input.textbox();
            var tb = input.textbox('textbox');
            tb.on('focus', function (e) {
                tb.select();
            });
            return input;
        },
        getValue: function (target) {
            return target.textbox('getValue');
        },
        setValue: function (target, value) {
            target.textbox('setValue', value);
        },
        resize: function (target, width) {
            target.textbox('resize', width);
        }
    },

    numberbox: {
        init: function (container, options) {
            var input = $('<input>').appendTo(container);
            input.numberbox(options);
            var tb = input.numberbox('textbox');
            tb.on('focus', function (e) {
                tb.select();
            });
            return input;
        },
        getValue: function (target) {
            var value = target.numberbox('getValue');
            if(value)
              return target.numberbox('getValue');
            else
              return 0;
        },
        setValue: function (target, value) {
            target.numberbox('setValue', value);
        },
        resize: function (target, width) {
            target.numberbox('resize', width);
        }
    },

    numberspinner: {
        init: function (container, options) {
            var input = $('<input>').appendTo(container);
            input.numberspinner(options);
            var tb = input.numberspinner('textbox');
            tb.on('focus', function (e) {
                tb.select();
            });
            return input;
        },
        getValue: function (target) {
            return target.numberspinner('getValue');
        },
        setValue: function (target, value) {
            target.numberspinner('setValue', value);
        },
        resize: function (target, width) {
            target.numberspinner('resize', width);
        }
    }

});