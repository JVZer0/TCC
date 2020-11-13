import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import Chart from "react-google-charts";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';

const api = new anuncioAPI();

export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [estadoAnuncio, setEstadoAnuncio] = useState([]);

    const anunciosPorEstado = async () =>{
        try {
            const resp = await api.anunciosPorEstado();
            setEstadoAnuncio(resp);
        } catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    useEffect(() => {
        anunciosPorEstado();
      }, []);

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Relatorio", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>

            <div className="rulf">

                <Chart
                    width={"700px"}
                    height={"400px"}
                    chartType="Bar"
                    loader={<div>Loading Chart</div>}
                    rows={estadoAnuncio.map((x) => (
                    [String(x.estado), x.qtdAnuncio, x.qtdVendido]))}

                    columns={["Estados", "Anuncios publicados", "Anuncios vendidos"]}
                
                    options={{
                    // Material design options
                    chart: {
                        title: "Anuncios por estados",
                    },
                    }}
                    // For tests
                    rootProps={{ "data-testid": "2" }}
                />
            </div>
            <ToastContainer/>
            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}