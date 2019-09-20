import Vue from 'vue'
import builds from './components/builds.vue'

let index = new Vue({
    el: '#builds',
    components: {
        builds
    },
    template: `
    <div>
        <builds />
    </div>`
});