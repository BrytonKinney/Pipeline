import Vue from 'vue';
import builds from './components/builds.vue';
var index = new Vue({
    el: '#builds',
    components: {
        builds: builds
    },
    template: "\n    <div>\n        <builds />\n    </div>"
});
//# sourceMappingURL=index.js.map